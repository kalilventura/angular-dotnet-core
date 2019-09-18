import { Component, OnInit, ViewChild } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product/product.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import swal from 'sweetalert2';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  public products: Product[];
  dataSource;
  displayedColumns: string[] = ['Id', 'Name', 'Description', 'Price', 'Bar Code', 'Actions'];

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit() {
    this.GetAllProducts();
  }

  GetAllProducts() {
    this.productService.getAllProducts().subscribe(
      (products: Array<Product>) => {
        this.products = products;
        this.dataSource = new MatTableDataSource(this.products);
        this.dataSource.paginator = this.paginator;
      }
    );
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  deleteProduct(id: number) {
    console.log('Deletado ', id);
    this.router.navigate([`product/deleteProduct/${id}`]);
  }

  alterProduct(id: number) {
    console.log('Alterar ', id);
    this.router.navigate([`/product/updateProduct/${id}`]);
  }

  AddProduct() {
    this.router.navigate(['/product/addProduct']);
  }

}
