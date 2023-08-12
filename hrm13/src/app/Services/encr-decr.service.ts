import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';
@Injectable({
  providedIn: 'root'
})
export class EncrDecrService {

  constructor() { }
  //The set method is use for encrypt the value.
  set(keys: any, value: any) {
    var key = CryptoJS.enc.Utf8.parse(keys);
    var iv = CryptoJS.enc.Utf8.parse(keys);
    var encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(value.toString()), key,
      {
        keySize: 128 / 8,
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
      });

    return encrypted.toString();
  }

  //The get method is use for decrypt the value.
  get(keys: any, value: any) {
    var key = CryptoJS.enc.Utf8.parse(keys);
    var iv = CryptoJS.enc.Utf8.parse(keys);
    var decrypted = CryptoJS.AES.decrypt(value, key, {
      keySize: 128 / 8,
      iv: iv,
      mode: CryptoJS.mode.CBC,
      padding: CryptoJS.pad.Pkcs7
    });

    return decrypted.toString(CryptoJS.enc.Utf8);
  }

  encryptSecretKey = "ANUNANINA@#!"; //adding secret key

  //Data Encryption Function
  encryptData(msg: any) {
    var keySize = 256;
    var salt = CryptoJS.lib.WordArray.random(16);
    var key = CryptoJS.PBKDF2(this.encryptSecretKey, salt, {
      keySize: keySize / 32,
      iterations: 100
    });

    var iv = CryptoJS.lib.WordArray.random(128 / 8);

    var encrypted = CryptoJS.AES.encrypt(msg, key, {
      iv: iv,
      padding: CryptoJS.pad.Pkcs7,
      mode: CryptoJS.mode.CBC
    });

    var result = CryptoJS.enc.Base64.stringify(salt.concat(iv).concat(encrypted.ciphertext));

    return result;
  }

  decrypt(key: any, ciphertextB64: any) {

    var _key: any = CryptoJS.enc.Utf8.parse(key);
    var iv = CryptoJS.lib.WordArray.create([0x00, 0x00, 0x00, 0x00]);

    var decrypted = CryptoJS.AES.decrypt(ciphertextB64, _key, { iv: iv });
    return decrypted.toString(CryptoJS.enc.Utf8);
  }
}
