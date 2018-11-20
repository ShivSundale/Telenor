import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import {AppComponent} from './app.component';
import { AppRoutingModule } from "./app-routing.module";
// import {TelenorComponent} from './components/telenor.component';
import {ProductListComponent} from './components/products/product-list/products-list.component';
import {ProductDetailComponent} from './components/products/product-detail/product-detail.component';
import {ProductService} from "./components/products/services/ProductService";
import { APP_BASE_HREF } from '@angular/common';

@NgModule({
    declarations: [
        AppComponent,
        // TelenorComponent,
        ProductListComponent,
        ProductDetailComponent,
    ],
    imports: [
        AppRoutingModule,
        BrowserModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [ProductService,{provide: APP_BASE_HREF, useValue: '/'}],
    bootstrap: [AppComponent]
})
export class AppModule {
}
