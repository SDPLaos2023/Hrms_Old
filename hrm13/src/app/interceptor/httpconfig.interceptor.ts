import { Injectable } from '@angular/core';
import {
    HttpInterceptor,
    HttpRequest,
    HttpResponse,
    HttpHandler,
    HttpEvent,
    HttpErrorResponse
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { UitlsService } from '../Services/shared/uitls.service';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
    constructor(private util: UitlsService, private cookies: CookieService) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let tokenkey = this.util.encryptUsingAES256("token");
        const token = this.cookies.get(tokenkey);

        request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
        // request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
        request = request.clone({ headers: request.headers.set('Accept', 'application/json') });
        // request = request.clone({ headers: request.headers.set('Access-Control-Allow-Origin', '*') });

        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    // console.log('event--->>>', event);
                }
                return event;
            }));
    }

}