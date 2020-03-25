import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.css']
})
export class EventosComponent implements OnInit {
  title = 'Pro Agil Eventos!';
  eventos: any = [];
  constructor(private http: HttpClient) {}

  ngOnInit() { this.getEventos(); }

  getEventos() {
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => {
        console.log(response);
        this.eventos = response;
      },
      error => {
        console.error(error);
      }
    );
  }
}
