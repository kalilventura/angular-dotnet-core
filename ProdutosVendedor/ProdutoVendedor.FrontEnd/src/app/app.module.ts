import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { ProductComponent } from './pages/product/product.component';
import { SellerComponent } from './pages/seller/seller.component';
import { AppRoutesModule } from './routes/routes';
import { IndexComponent } from './pages/index/index.component';
import { AddProductComponent } from './pages/product/add-product/add-product.component';
import { ProductService } from './services/product/product.service';
import { SellerService } from './services/seller/seller.service';
import { AddSellerComponent } from './pages/seller/add-seller/add-seller.component';
import { DeleteProductComponent } from './pages/product/delete-product/delete-product.component';
import { UpdateProductComponent } from './pages/product/update-product/update-product.component';
import { DeleteSellerComponent } from './pages/seller/delete-seller/delete-seller.component';
import { UpdateSellerComponent } from './pages/seller/update-seller/update-seller.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    SellerComponent,
    IndexComponent,
    AddProductComponent,
    AddSellerComponent,
    DeleteProductComponent,
    UpdateProductComponent,
    DeleteSellerComponent,
    UpdateSellerComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    AppRoutesModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ProductService, SellerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
