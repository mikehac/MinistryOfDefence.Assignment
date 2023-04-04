import { Component, Input } from '@angular/core';
import { category, item } from '../shopping.service';

@Component({
  selector: 'category-items',
  templateUrl: './category-items.component.html',
  styleUrls: ['./category-items.component.css'],
})
export class CategoryItemsComponent {
  @Input() category: category;

  calculateTotal(items: item[]) {
    return items.reduce((sum, current) => sum + current.amount, 0);
  }
}
