import { Component, OnInit } from '@angular/core';
import { ShoppingService, category } from './shopping.service';
import { State } from './state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  categoryList: category[] = [];
  categoriesWithItem: category[] = [];
  newItemName: string = '';
  selectedCategoryId: number = 0;
  state = new State();
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
      let totalCounter = 0;
      this.categoriesWithItem.forEach((x) => {
        x.items.forEach((item) => {
          totalCounter += item.amount;
        });
      });

      this.state.update(totalCounter);
    });
  }

  private addNewItem() {
    var newItem = {
      id: 0,
      name: this.newItemName,
      categoryId: this.selectedCategoryId,
      amount: 1,
    };
    // console.log(newItem);
    this.service.addNewItem(newItem).subscribe((response) => {
      this.getAllItems();
      this.newItemName = '';
      this.selectedCategoryId = 0;
    });
  }

  onClick() {
    console.log(this.selectedCategoryId);
    this.addNewItem();
  }
}
