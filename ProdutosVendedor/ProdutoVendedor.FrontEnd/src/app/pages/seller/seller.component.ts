import { Component, OnInit, ViewChild } from '@angular/core';
import { SellerService } from 'src/app/services/seller/seller.service';
import { Seller } from 'src/app/models/seller.model';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { Router, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.css']
})
export class SellerComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  public sellers: Array<Seller>;
  dataSource;
  displayedColumns: string[] = ['Id', 'Name', 'Telephone', 'Commission Value', 'Actions'];

  constructor(private sellerService: SellerService, private router: Router) { }

  ngOnInit() {
    this.getAllSellers();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getAllSellers() {
    this.sellerService.getAllSellers().subscribe(
      (sellers: Seller[]) => {
        this.sellers = sellers;
        this.dataSource = new MatTableDataSource(this.sellers);
        this.dataSource.paginator = this.paginator;
      }
    );
  }

  deleteSeller(id: number) {
    console.log('Deletado ', id);
    this.router.navigate([`/seller/deleteSeller/${id}`]);
  }

  alterSeller(id: number) {
    console.log('Alterar ', id);
    this.router.navigate([`seller/updateSeller/${id}`]);
  }

  AddSeller() {
    this.router.navigate(['/seller/addSeller']);
  }

}
