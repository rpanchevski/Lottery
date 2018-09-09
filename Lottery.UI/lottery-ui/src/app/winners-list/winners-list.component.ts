import { Component, OnInit } from '@angular/core';
import { WinnersListService } from './winners-list.service';
import { UserCodeAward } from './winners-list.model';

@Component({
  selector: 'app-winners-list',
  templateUrl: './winners-list.component.html',
  styleUrls: ['./winners-list.component.css']
})
export class WinnersListComponent implements OnInit {
  winners: Array<UserCodeAward>;
  constructor(private winnersService: WinnersListService) {
    this.winners = [];
  }

  ngOnInit() {
    this.winnersService.getAllWinners().subscribe((result) => {
      this.winners = result;
    }, (error) => { })
  }

}
