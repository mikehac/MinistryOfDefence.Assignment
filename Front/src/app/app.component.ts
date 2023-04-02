import { Component, OnInit } from '@angular/core';
import { ShoppingService, category } from './shopping.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ShopingList.Front';
  categoryList:category[]=[];
  constructor(private service:ShoppingService) { }
  ngOnInit(): void {
    this.getAllCategories();
  }

  private getAllCategories(){
    this.service.getCategories()
    .subscribe(r=>{
      this.categoryList=r;
      console.log(r);
    })
  }
}
