import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

const SECRET_KEY: string = "0123456789d2345g"
@Injectable({
  providedIn: 'root'
})
export class UitlsService {

  constructor() { }

  encryptUsingAES256(request: any) {

    let _key = CryptoJS.enc.Utf8.parse(SECRET_KEY);
    let _iv = CryptoJS.enc.Utf8.parse(SECRET_KEY);
    let encrypted = CryptoJS.AES.encrypt(
      JSON.stringify(request), _key, {
      keySize: 16,
      iv: _iv,
      mode: CryptoJS.mode.ECB,
      padding: CryptoJS.pad.Pkcs7
    });
    return encrypted.toString();
  }
  decryptUsingAES256(responce: any) {
    let _key = CryptoJS.enc.Utf8.parse(SECRET_KEY);
    let _iv = CryptoJS.enc.Utf8.parse(SECRET_KEY);

    return CryptoJS.AES.decrypt(
      responce, _key, {
      keySize: 16,
      iv: _iv,
      mode: CryptoJS.mode.ECB,
      padding: CryptoJS.pad.Pkcs7
    }).toString(CryptoJS.enc.Utf8);
  }


  ageCalculator(age: any) {
    if (age) {
      const convertAge = new Date(age);
      const timeDiff = Math.abs(Date.now() - convertAge.getTime());
      let showAge = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365);
      return showAge;
    }
    return "0";
  }
}
