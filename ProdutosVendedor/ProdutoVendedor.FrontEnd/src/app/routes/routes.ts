import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { ProductComponent } from '../pages/product/product.component';
import { SellerComponent } from '../pages/seller/seller.component';
import { IndexComponent } from '../pages/index/index.component';
import { AddProductComponent } from '../pages/product/add-product/add-product.component';
import { AddSellerComponent } from '../pages/seller/add-seller/add-seller.component';
import { UpdateSellerComponent } from '../pages/seller/update-seller/update-seller.component';
import { DeleteSellerComponent } from '../pages/seller/delete-seller/delete-seller.component';
import { UpdateProductComponent } from '../pages/product/update-product/update-product.component';
import { DeleteProductComponent } from '../pages/product/delete-product/delete-product.component';

const appRoutes: Routes = [
    { path: '', component: IndexComponent },
    { path: 'product', component: ProductComponent },
    { path: 'product/addProduct', component: AddProductComponent },
    { path: 'product/updateProduct/:id', component: UpdateProductComponent },
    { path: 'product/deleteProduct/:id', component: DeleteProductComponent },
    { path: 'seller', component: SellerComponent },
    { path: 'seller/addSeller', component: AddSellerComponent },
    { path: 'seller/updateSeller/:id', component: UpdateSellerComponent },
    { path: 'seller/deleteSeller/:id', component: DeleteSellerComponent }
];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forRoot(appRoutes),
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutesModule { }
