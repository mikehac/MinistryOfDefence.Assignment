import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShoppingService {
  private baseUrl: string;
  constructor(private http: HttpClient) { 
    this.baseUrl = environment.apiUrl;
  }

  public getCategories(){
    return this.http.get<category[]>(this.baseUrl);
  }
}
export interface category{
  id: number,
  name: string,
  nameHeb: string
}