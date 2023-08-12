import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { Location } from '@angular/common'

@Injectable({
  providedIn: 'root'
})
export class NoneGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router, private _location: Location) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.auth.isAuthenticated()) {
      this.router.navigate(["dashboard"])
      return false;
    }
    return true;
  }
}
