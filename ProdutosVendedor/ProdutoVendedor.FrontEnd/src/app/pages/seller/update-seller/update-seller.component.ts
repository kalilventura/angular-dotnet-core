import { Component, OnInit } from '@angular/core';
import { Seller } from 'src/app/models/seller.model';
import { SellerService } from 'src/app/services/seller/seller.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import swal from 'sweetalert2';

@Component({
  selector: 'app-update-seller',
  templateUrl: './update-seller.component.html',
  styleUrls: ['./update-seller.component.css']
})
export class UpdateSellerComponent implements OnInit {

  seller: Seller;
  constructor(private fb: FormBuilder, private sellerService: SellerService, private router: Router, private route: ActivatedRoute) { }

  sellerForm = this.fb.group({
    name: ['', Validators.required],
    telephone: ['', Validators.required],
    commissionValue: ['', Validators.required]
  });


  ngOnInit() {
    this.productToUpdate();
  }

  onSubmit() {
    console.log(this.sellerForm.value);
    const sellerId: number = +this.route.snapshot.paramMap.get('id');
    this.sellerService.alterSeller(this.sellerForm.value, sellerId).subscribe(
      (p: Seller) => {
        console.log(p);
        swal.fire({
          position: 'center',
          type: 'success',
          title: 'Vendedor alterado com sucesso !!',
          text: `Vendedor alterado com sucesso no sistema`,
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
    this.router.navigate(['/seller']);
  }

  Clear() {
    this.sellerForm.reset();
  }

  productToUpdate() {
    const productId: number = +this.route.snapshot.paramMap.get('id');
    this.sellerService.getSellerById(productId).subscribe(
      (seller: Seller) => {
        this.seller = seller;
        console.log(this.seller);
      }
    );
  }

}
