import { Component, OnInit } from '@angular/core';
import { AuthService } from './Services/auth.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private auth: AuthService) {}

  ngOnInit() {
    //console.log("Loading User")
    this.auth.loadCurrentUser().subscribe();
  }


  title = 'Personal Website';
}
