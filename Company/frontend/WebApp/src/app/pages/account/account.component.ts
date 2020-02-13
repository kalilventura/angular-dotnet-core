import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  constructor() { }
  userData: any;

  ngOnInit() {
    this.getUserData();
  }

  getUserData() {
    const data = localStorage.getItem('login');
    console.log(data);
    this.userData = JSON.parse(data);
    console.log(this.userData);
  }

}
