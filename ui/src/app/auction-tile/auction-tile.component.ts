import { Component, Input, OnInit } from '@angular/core';
import { Auction } from '../models/auction';

@Component({
  selector: 'app-auction-tile',
  templateUrl: './auction-tile.component.html',
  styleUrls: ['./auction-tile.component.scss']
})
export class AuctionTileComponent implements OnInit {
  @Input() auction?: Auction;

  

  constructor() { }

  ngOnInit(): void {
  }

}
