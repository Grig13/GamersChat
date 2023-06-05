import { Component, OnDestroy, OnInit } from '@angular/core';
import { SignalrService } from 'src/services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit, OnDestroy {

  title = 'app';

  constructor(public signalrService: SignalrService) {}
  
  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
