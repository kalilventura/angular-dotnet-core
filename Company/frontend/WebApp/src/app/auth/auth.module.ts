import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthRoutingModule } from './auth.routing.module';
import { MaterialModule } from '../material.module';
import { AuthInterceptor } from './auth.interceptor';

@NgModule({
    declarations: [LoginComponent, RegisterComponent],
    imports: [
        CommonModule,
        AuthRoutingModule,
        MaterialModule,
        ReactiveFormsModule
    ]
})

export class AuthModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: AuthModule,
            providers: [AuthInterceptor]
        };
    }
}
