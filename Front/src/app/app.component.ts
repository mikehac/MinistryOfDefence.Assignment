import { Component, OnInit } from '@angular/core';
import { ShoppingService, category } from './shopping.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  categoryList: category[] = [];
  categoriesWithItem: category[] = [];
  newItem: string = '';
  selectedCategoryId: number = 0;
  constructor(private service: ShoppingService) {}
  ngOnInit(): void {
    this.getAllCategories();
    this.getAllItems();
  }

  private getAllCategories() {
    this.service.getCategories().subscribe((r) => {
      this.categoryList = r;
      // console.log(r);
    });
  }

  private getAllItems() {
    this.service.getAllItems().subscribe((r) => {
      this.categoriesWithItem = r;
      console.log(this.categoriesWithItem);
    });
  }

  private addNewItem() {
    var newItem = {
      id: 0,
      name: this.newItem,
      categoryId: this.selectedCategoryId,
    };
    // console.log(newItem);
    this.service.addNewItem(newItem).subscribe((response) => {
      this.getAllItems();
    });
  }

  onClick() {
    console.log(this.selectedCategoryId);
    this.addNewItem();
  }
}
