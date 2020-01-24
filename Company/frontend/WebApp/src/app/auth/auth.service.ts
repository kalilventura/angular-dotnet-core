import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { environment } from '../../environments/environment';
@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private subjUser$: BehaviorSubject<User> = new BehaviorSubject(null);
    private subjLoggedIn$: BehaviorSubject<boolean> = new BehaviorSubject(true);
    private readonly url: string = `${environment.api_route}/auth`;

    constructor(private http: HttpClient) { }

    register(user: User): Observable<User> {
        return this.http.post<User>(`${this.url}/register`, user);
    }

    logout() {
        localStorage.removeItem('token');
        this.subjLoggedIn$.next(false);
        this.subjUser$.next(null);
    }

    login(credentials: { email: string, password: string }): Observable<User> {
        return this.http
            .post<User>(`${this.url}/login`, credentials)
            .pipe(tap((user: User) => {
                localStorage.setItem('token', user.token);
                this.subjLoggedIn$.next(true);
                this.subjUser$.next(user);
            }));
    }

    isAuthenticated(): Observable<boolean> {
        // const token = localStorage.getItem('token');
        // if (token && !this.subjLoggedIn$.value) {
        //     return this.checkTokenValidation();
        // }
        return this.subjLoggedIn$.asObservable();
    }

    checkTokenValidation(): Observable<boolean> {
        return this.http
            .get<User>(`${this.url}/checkToken`)
            .pipe(
                tap((u: User) => {
                    if (u) {
                        localStorage.setItem('token', u.token);
                        this.subjLoggedIn$.next(true);
                        this.subjUser$.next(u);
                    }
                }),
                map((u: User) => (u) ? true : false),
                catchError((err) => {
                    this.logout();
                    return of(false);
                })
            );
    }

    getUser(): Observable<User> {
        return this.subjUser$.asObservable();
    }

}
