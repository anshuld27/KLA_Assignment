import { Component } from '@angular/core';
import { BackendService } from '../../services/backend.service';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-converter',
  templateUrl: './converter.component.html',
  styleUrl: './converter.component.css'
})
export class ConverterComponent {
  amount: string = '';
  serverResponse!: string;

  constructor(private currencyConverterService: BackendService) { }

  convert() {
    if (this.amount.trim() === '') {
      this.serverResponse = 'Input is empty. Please provide a value.';
      return;
    }
    this.serverResponse = '';
    this.currencyConverterService.convertCurrency(this.amount)
    // .subscribe(response => {
    //   this.serverResponse = response; // Assign response to variable
    // },);
    .subscribe({
      next: (data) => {
        this.serverResponse = data;
        console.log(data);
      },
      error: (e) =>{ 
        this.serverResponse = e.error;
      }
    });
  }

  clearInput() {
    this.amount = '';
    this.serverResponse= '';
  }
}