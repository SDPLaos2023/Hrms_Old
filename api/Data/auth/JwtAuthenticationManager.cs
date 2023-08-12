using hrm_api.Data.hr;
using hrm_api.Models;
using hrm_api.Models.auth;
using hrm_api.Services;
using hrm_api.Services.Interfaces.auth;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hrm_api.Data.auth
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {

        private readonly string key;
        public List<User> users { get; set; }
        private readonly IConfiguration configuration;

        private readonly ILog _logger = LogManager.GetLogger(typeof(JwtAuthenticationManager));

        public JwtAuthenticationManager(IConfiguration configuration)
        {
            this.configuration = configuration;

            this.key = this.configuration["Keys:secret"];
        }
        public async Task<string> Authenticate(string username, string password)
        {
            try
            {
                string encrypted = this.Encrypt(password);
                using (var connection = new MySqlConnection(this.configuration["ConnectionStrings:Default"]))
                {

                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    using (var command = new MySqlCommand("SELECT * FROM auth_users where username=@username and password=@password;",
                    connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", encrypted);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            users = new List<User>();
                            while (await reader.ReadAsync())
                            {
                                User user = new User();
                                user.ID = reader.GetString(0);
                                user.employee = reader.GetString(3);
                                user.status = reader.GetString(4);
                                user.username = username;
                                user.role = reader.GetString(5);
                                //user.rule = reader.GetString(6) == null?"":"";
                                users.Add(user);
                            }
                            if (this.users.Count <= 0) { return null; }

                        }
                        command.Dispose();
                    }
                    connection.Dispose();
                }

                var u = new UserServices(this.configuration).GetNoPassword(users[0].ID);
                var e = new EmployeeServices(this.configuration).Get(users[0].employee);
                var d = new EmployeeEmploymentServices().GetEmployment(users[0].employee);
                var fpuser = new attendance.DeviceUsersServices(this.configuration).GetFpUserId(users[0].employee);


                IDictionary<string, object> openWith = new Dictionary<string, object>();

                openWith.Add("username", username);
                openWith.Add("user", u);
                openWith.Add("employee", users[0].employee);
                openWith.Add("employeefullnamela", e.Name);
                openWith.Add("employeefullnameen", e.NameEn);
                openWith.Add("dept", d);
                openWith.Add("fpuser", fpuser);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(this.key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role,users[0].role)
                }),
                    Claims = openWith,
                    Expires = DateTime.UtcNow.AddDays(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        private static string GenerateEncryptionKey()
        {
            string EncryptionKey = string.Empty;
            EncryptionKey = "ANUNANINA@#!";// + Convert.ToString(Rnumber);

            return EncryptionKey;
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = GenerateEncryptionKey();
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
