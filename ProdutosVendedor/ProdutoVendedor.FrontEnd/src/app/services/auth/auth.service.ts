import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { User } from './user';
import { tap, map, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    readonly url = 'http://localhost:3000/auth';

    private subjUser$: BehaviorSubject<User> = new BehaviorSubject(null);
    private subjLoggedIn$: BehaviorSubject<boolean> = new BehaviorSubject(false);

    constructor(private http: HttpClient) { }

    register(user: User): Observable<User> {
        return this.http.post<User>(`${this.url}/register`, user);
    }

    login(credentials: { email: string, password: string }): Observable<User> {
        return this.http
            .post<User>(`${this.url}/login`, credentials)
            .pipe(
                tap((u: User) => {
                    localStorage.setItem('token', u.token);
                    this.subjLoggedIn$.next(true);
                    this.subjUser$.next(u);
                })
            );
    }

    isAuthenticated(): Observable<boolean> {
        const token = localStorage.getItem('token');
        if (token && !this.subjLoggedIn$.value) {
            return this.checkTokenValidation();
        }
        return this.subjLoggedIn$.asObservable();
    }

    checkTokenValidation(): Observable<boolean> {
        return this.http
            .get<User>(`${this.url}/user`)
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

    logout() {
        localStorage.removeItem('token');
        this.subjLoggedIn$.next(false);
        this.subjUser$.next(null);
    }
}
