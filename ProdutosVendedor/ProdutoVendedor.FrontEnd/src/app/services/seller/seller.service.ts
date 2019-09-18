import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Seller } from 'src/app/models/seller.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  private sellerApi = `${environment.apiService}/api/seller`;
  constructor(private http: HttpClient) { }

  getAllSellers(): Observable<Array<Seller>> {
    return this.http.get<Seller[]>(`${this.sellerApi}/GetAllSellersAsync`);
  }

  saveSeller(seller: Seller): Observable<Seller> {
    return this.http.post<Seller>(`${this.sellerApi}/RegisterSellerAsync`, seller);
  }

  deleteSeller(sellerId: number){
    return this.http.delete(`${this.sellerApi}/${sellerId}`);
  }

  getSellerById(sellerId: number): Observable<Seller> {
    return this.http.get<Seller>(`${this.sellerApi}/${sellerId}`);
  }

  alterSeller(seller: Seller, sellerId: number): Observable<Seller> {
    return this.http.put<Seller>(`${this.sellerApi}/${sellerId}`, seller);
  }

}
