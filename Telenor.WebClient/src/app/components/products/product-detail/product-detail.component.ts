import {Component, OnInit} from '@angular/core';
import {ProductService} from "../services/ProductService";
import {Subscription} from "rxjs/internal/Subscription";
import {Product} from "../viewmodels/product";
import { ActivatedRoute } from "@angular/router";
import {Observable} from 'rxjs/Observable';
import 'rxjs';

@Component({
    selector: 'app-product-detail',
    templateUrl: './product-detail.component.html',
    styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
    
    constructor(private productService: ProductService, private route: ActivatedRoute) 
    {
    }

    ngOnInit():void {
        const id = +this.route.snapshot.params["id"];
        //this.reset(id);
        this.loadProductDetail(id);
    }

    loadProductDetail(id: number ) {
        this.productService.getProduct(id);
    }

    reset(id: number) {
        this.loadProductDetail(id);
    }
}
