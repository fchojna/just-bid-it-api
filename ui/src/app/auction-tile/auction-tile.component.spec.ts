import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionTileComponent } from './auction-tile.component';

describe('AuctionTileComponent', () => {
  let component: AuctionTileComponent;
  let fixture: ComponentFixture<AuctionTileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionTileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
