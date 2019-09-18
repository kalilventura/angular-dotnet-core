import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SellerService } from 'src/app/services/seller/seller.service';
import { Seller } from 'src/app/models/seller.model';
import swal from 'sweetalert2';

@Component({
  selector: 'app-add-seller',
  templateUrl: './add-seller.component.html',
  styleUrls: ['./add-seller.component.css']
})
export class AddSellerComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router, private sellerService: SellerService) { }

  sellerForm = this.fb.group({
    name: ['', Validators.required],
    telephone: ['', Validators.required],
    commissionValue: ['', Validators.required]
  });

  ngOnInit() {

  }

  onSubmit() {
    console.log(this.sellerForm.value);
    this.sellerService.saveSeller(this.sellerForm.value).subscribe(
      (seller: Seller) => {
        console.log(seller);
        swal.fire({
          position: 'center',
          type: 'success',
          title: 'Vendedor cadastrado com sucesso !!',
          text: `${seller.name} cadastrado com sucesso`,
          showConfirmButton: true
        });
        this.goBack();
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
      }
    );
  }

  clear() {
    console.log('limpar');
    this.sellerForm.reset();
  }

  goBack() {
    this.router.navigate(['/seller']);
  }

}
