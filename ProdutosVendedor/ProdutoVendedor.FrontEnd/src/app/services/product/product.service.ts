import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private productApi = `${environment.apiService}/api/product`;
  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.productApi}`);
  }

  saveProduct(p: Product): Observable<Product> {
    return this.http.post<Product>(`${this.productApi}/RegisterProduct`, p);
  }

  deleteProduct(id: number) {
    return this.http.delete(`${this.productApi}/${id}`);
  }

  getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.productApi}/${id}`);
  }

  alterProduct(product: Product, id: number): Observable<Product> {
    return this.http.put<Product>(`${this.productApi}/${id}`, product);
  }
}
