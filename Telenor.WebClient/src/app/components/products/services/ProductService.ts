import {Subject} from "rxjs/internal/Subject";
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Product } from "../viewmodels/product";
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ProductService {
    ProductList: Product[];
    Product: Product;
    ProductApiBaseUrl: string;
    ProductApiUrl: string;
    ProductPicBasePath: string;
    constructor(private http: HttpClient) {
        this.ProductApiBaseUrl = 'https://localhost:44310/';
        this.ProductApiUrl = 'https://localhost:44310/api/v1/product/';
        this.ProductPicBasePath = this.ProductApiBaseUrl + 'ProductPics/'
    }

    getAllProducts() {
        const headers = new HttpHeaders().set('Accept', 'application/json')
        
        this.http.get(this.ProductApiUrl, {headers: headers})
                .map(res => res as Product[]).toPromise().then(x => {
                         this.ProductList = x;
                        });
      }

    getProduct(id: number) {
        const headers = new HttpHeaders().
        set('Accept', 'application/json')
        this.http.get(this.ProductApiUrl + id, {headers: headers})
        .map(res => res as Product).toPromise().then(x => {
            this.Product = x;
          });
      }
      getProductImageUrl()
      {
          console.log(this.Product);
        return this.ProductPicBasePath+this.Product.PictureFileName;
      }
}
