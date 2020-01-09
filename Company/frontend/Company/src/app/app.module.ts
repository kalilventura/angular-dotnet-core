import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { HomeComponent } from './pages/home/home.component';
import { RoutingModule } from './routing/routing.module';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { CompanyComponent } from './pages/company/company.component';
import { LoginComponent } from './oauth/login/login.component';
import { LogoutComponent } from './oauth/logout/logout.component';
import { ProfileComponent } from './oauth/profile/profile.component';
import { RegisterComponent } from './oauth/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    LoginComponent,
    LogoutComponent,
    ProfileComponent,
    RegisterComponent,
    HomeComponent,
    HeaderComponent,
    SidenavListComponent,
    CompanyComponent,
    EmployeeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    RoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
