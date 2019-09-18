import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product/product.service';
import { throwMatDialogContentAlreadyAttachedError } from '@angular/material';
import { Observable } from 'rxjs';
import swal from 'sweetalert2';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {

  productDelete: Product;
  constructor(private router: Router, private route: ActivatedRoute, private productService: ProductService) { }

  ngOnInit() {
    this.getDataProductToDelete();
  }

  goBack() {
    this.router.navigate(['/product']);
  }

  goDelete() {
    const productId: number = +this.route.snapshot.paramMap.get('id');
    console.log(productId);
    this.productService.deleteProduct(productId).subscribe(
      () => {
        swal.fire({
          position: 'center',
          type: 'info',
          title: 'Produto deletado com sucesso !!',
          text: `O produto foi deletado com sucesso do sistema.`,
          showConfirmButton: true
        });
        this.goBack();
      },
      (error) => {
        swal.fire({
          position: 'center',
          type: 'error',
          title: 'Ocorreu um erro',
          text: `Por favor, espere um momento e tente novamente.`,
          showConfirmButton: true
        });
      }
    );
  }

  getDataProductToDelete() {
    const productId: number = +this.route.snapshot.paramMap.get('id');
    this.productService.getProductById(productId).subscribe(
      (product: Product) => {
        this.productDelete = product;
      }
    );
  }
}
