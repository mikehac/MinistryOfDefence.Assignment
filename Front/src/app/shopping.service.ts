import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ShoppingService {
  private baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = environment.apiUrl;
  }

  public getCategories() {
    return this.http.get<category[]>(this.baseUrl);
  }

  public getAllItems() {
    return this.http.get<category[]>(this.baseUrl + 'GetAllItems');
  }

  public addNewItem(newItem: item) {
    return this.http.post<item>(this.baseUrl, newItem).pipe(
      map((respose) => {
        return respose;
      })
    );
  }
}
export interface category {
  id: number;
  name: string;
  nameHeb: string;
  items: item[];
}
export interface item {
  id: number;
  name: string;
  categoryId: number;
}
