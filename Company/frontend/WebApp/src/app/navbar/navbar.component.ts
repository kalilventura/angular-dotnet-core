import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';
import { User } from '../models/user.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  authenticated$: Observable<boolean>;
  user$: Observable<User>;


  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/auth/login');
  }

  constructor(private breakpointObserver: BreakpointObserver, private authService: AuthService, private router: Router
  ) {
    this.authenticated$ = this.authService.isAuthenticated();
    this.user$ = this.authService.getUser();
  }

}
