import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProductService } from 'src/app/services/product/product.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import swal from 'sweetalert2';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {

  constructor(private fb: FormBuilder, private productService: ProductService, private router: Router, private route: ActivatedRoute) { }

  product: Product;

  productForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    barCode: ['', Validators.required],
    price: [0, Validators.required]
  });

  ngOnInit() {
    this.productToUpdate();
  }

  onSubmit() {
    console.log(this.productForm.value);
    const productId: number = +this.route.snapshot.paramMap.get('id');
    this.productService.alterProduct(this.productForm.value, productId).subscribe(
      (p: Product) => {
        console.log(p);
        swal.fire({
          position: 'center',
          type: 'success',
          title: 'Produto alterado com sucesso !!',
          text: `${p.name} alterado com sucesso no sistema`,
          showConfirmButton: true
        });
        this.GoBack();
      },
      (err) => {
        console.log(err);
        swal.fire({
          position: 'center',
          type: 'error',
          title: 'Ocorreu um erro',
          text: `Ocorreu um erro, por favor verifique e tente novamente`,
          showConfirmButton: true
        });
      });
  }

  GoBack() {
    this.router.navigate(['/product']);
  }

  Clear() {
    this.productForm.reset();
  }

  productToUpdate() {
    const productId: number = +this.route.snapshot.paramMap.get('id');
    this.productService.getProductById(productId).subscribe(
      (product: Product) => {
        this.product = product;
        console.log(this.product);
      }
    );
  }

}
