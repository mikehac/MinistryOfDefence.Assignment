import { Component, Input } from '@angular/core';
import { category } from '../shopping.service';

@Component({
  selector: 'category-items',
  templateUrl: './category-items.component.html',
  styleUrls: ['./category-items.component.css'],
})
export class CategoryItemsComponent {
  @Input() category: category;
}
