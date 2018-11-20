import {Component, OnInit} from '@angular/core';
import {ProductService} from "src/app/components/products/services/ProductService";
import {Subscription} from "rxjs/internal/Subscription";
import {Product} from "src/app/components/products/viewmodels/product";

@Component({
    selector: 'app-products',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    constructor(private productService: ProductService) {
    }

    ngOnInit(): void {
        this.reset();
        this.loadProducts();
    }

    loadProducts() {
        this.productService.getAllProducts();
    }   

    reset() {
        this.loadProducts();
    }
}
