import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SellerService } from 'src/app/services/seller/seller.service';
import { Seller } from 'src/app/models/seller.model';
import swal from 'sweetalert2';

@Component({
  selector: 'app-delete-seller',
  templateUrl: './delete-seller.component.html',
  styleUrls: ['./delete-seller.component.css']
})
export class DeleteSellerComponent implements OnInit {

  sellerDelete: Seller;
  constructor(private router: Router, private route: ActivatedRoute, private sellerService: SellerService) { }

  ngOnInit() {
    this.getDataProductToDelete();
  }

  goBack() {
    this.router.navigate(['seller']);
  }

  goDelete() {
    const sellerId: number = +this.route.snapshot.paramMap.get('id');
    console.log(sellerId);
    this.sellerService.deleteSeller(sellerId).subscribe(
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
      });
  }

  getDataProductToDelete() {
    const sellerId: number = +this.route.snapshot.paramMap.get('id');
    this.sellerService.getSellerById(sellerId).subscribe(
      (seller: Seller) => {
        this.sellerDelete = seller;
      }
    );
  }

}
