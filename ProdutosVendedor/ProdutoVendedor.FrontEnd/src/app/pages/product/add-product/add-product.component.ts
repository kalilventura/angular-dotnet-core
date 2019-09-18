import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProductService } from 'src/app/services/product/product.service';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import swal from 'sweetalert2';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  constructor(private fb: FormBuilder, private productService: ProductService, private router: Router) { }

  productForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    barCode: ['', Validators.required],
    price: [0, Validators.required]
  });
  
  ngOnInit() {
  }

  onSubmit() {
    console.log(this.productForm.value);
    this.productService.saveProduct(this.productForm.value).subscribe(
      (p: Product) => {
        console.log(p);
        swal.fire({
          position: 'center',
          type: 'success',
          title: 'Produto cadastrado com sucesso !!',
          text: `${p.name} cadastrado com sucesso no sistema`,
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

}
