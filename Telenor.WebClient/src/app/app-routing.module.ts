import { Component,NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ProductListComponent } from "./components/products/product-list/products-list.component";
import { ProductDetailComponent } from "./components/products/product-detail/product-detail.component";
import {APP_BASE_HREF} from '@angular/common';

const routes: Routes = [
  { path: "", component: ProductListComponent },
  { path: "details/:id", component: ProductDetailComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }