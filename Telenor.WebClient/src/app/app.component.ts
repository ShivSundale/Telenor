import {Component} from '@angular/core';
import {ProductService} from "./components/products/services/ProductService";

@Component({
    selector: 'app-root',
    template: "<router-outlet></router-outlet>",
    // templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [ProductService]
})
export class AppComponent {

}
