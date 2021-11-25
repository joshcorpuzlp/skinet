import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

//the component decorator designates which html selector all that's beloe will be under.
//it will also describe where the html is stored as well as the connected scss file that is styling the component
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent implements OnInit {
  
  //we declare 'title' as a variable that can be called using {{}} inside the app.component.html
  title = 'Skinet';

  //we declare 'products' as an array of 'IProduct' datatype that can be called using {{}} inside the app.component.html
  //IProduct is an interface that represents our Product object from API
  products: IProduct[];

  //we set the constructor of the AppComponent class to take a private HttpClient called http as a parameter.
  constructor(private http: HttpClient) {

  }

  //this is the method called on ngOnInit()
  ngOnInit(): void {

    //using the ngOnInit method, we connect to the API endpoint from dotnet API and subsequently subscribe
    //we then save the response to an 'IPagination' object here called 'response' and then save the data to the products array of 'IProduct' objects.
    this.http.get('https://localhost:5001/api/products?pageSize=50').subscribe((response: IPagination) => {
      console.log(response);
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }
}

//when this app-root is hit in the html, all of the code within app.component will be executed.