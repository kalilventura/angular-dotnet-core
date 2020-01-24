import { HttpInterceptor, HttpRequest, HttpHandler, HttpErrorResponse, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(
        private authService: AuthService,
        private router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (localStorage.getItem('token')) {
            const token = localStorage.getItem('token');
            const authReq = req.clone({
                setHeaders: {
                    Authorization: token
                }
            });
            return next.handle(authReq)
                .pipe(
                    catchError(
                        (error) => {
                            console.log(error);
                            // Trata somente o erro quando for a resposta do servidor
                            if (error instanceof HttpErrorResponse) {
                                if (error.status === 401) {
                                    this.authService.logout();
                                    this.router.navigateByUrl('/auth/login');
                                }
                            }
                            return throwError(error);
                        }
                    )
                );
        }
        return next.handle(req);
    }
}
