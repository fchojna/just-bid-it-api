import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Auction } from '../models/auction';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  foundCount = 3;
  makes: string[] = ['Audi'];
  models: string[] = ['A4'];
  generations: string[] = ['B6', 'B8', 'B9'];
  years: string[] = ['2021', '2020', '2019', '2018', '2017', '2016', '2015', '2014', '2013', '2012', '2011', '2010', '2009', '2008', '2007',
    '2006', '2005', '2004', '2003', '2002', '2001', '2000', '1999', '1998', '1997', '1996', '1995', '1994', '1993', '1992', '1991', '1990'];
  prices: number[] = [1000, 1500, 2000, 3000, 5000, 7500, 10000, 15000, 20000, 30000, 50000, 75000, 100000,
    125000, 150000, 200000, 250000, 500000, 1000000];
  distances: number[] = [20000, 35000, 50000, 75000, 100000, 125000, 150000, 200000, 250000, 30000];
  bodyTypes: string[] = ['Hatchback', 'Saloon', 'Estate', 'MVC', 'SUV', 'Coupe', 'Cabrio'];
  fuelTypes: string[] = ['Petrol', 'Diesel', 'Autogas (LPG)', 'Bi Fuel (CNG)', 'Electric', 'Electric/Hybrid'];
  powers: number[] = [50, 80, 120, 150, 200, 250, 300, 500];
  capacities: number[] = [1000, 1250, 1500, 2000, 2500, 3000, 4000, 5000, 6000, 7500];
  gearboxTypes: string[] = ['Manual', 'Automatic'];
  driveTypes: string[] = ['FWD', 'RWD', '4WD', 'AWD'];
  countries: string[] = ['Austria', 'Belgium', 'Belarus', 'Bulgaria', 'Canada', 'Croatia', 'Czech Republic', 'Denmark', 'Estonia',
    'Finland', 'France', 'Germany', 'Greece', 'Hungary', 'Iceland', 'Ireland', 'Italy', 'Latvia', 'Lichtenstein', 'Lithuania', 'Luxembourg',
    'Monaco', 'Netherlands', 'Norway', 'Poland', 'Romania', 'Russia', 'Slovakia', 'Slovenia', 'Spain', 'Switzerland', 'Sweden', 'Turkey', 'Ukraine',
    'United Kingdom', 'United States', 'Other'];

  allAuctions: Auction[] = [];
  auctionOfTheDay?: Auction;

  constructor(private fb: FormBuilder, private ds: DataService) { }

  searchForm = this.fb.group({
    make: [''],
    model: [''],
    generation: [''],
    productionYearFrom: [''],
    productionYearTo: [''],
    mileageMin: [''],
    mileageMax: [''],
    priceMin: [''],
    priceMax: [''],
    fuelType: [''],
    powerMin: [''],
    powerMax: [''],
    capacityMax: [''],
    capacityMin: [''],
    gearbox: [''],
    driveType: [''],
    country: [''],
  });

  ngOnInit(): void {

    this.ds.getAuctionById(1003).subscribe(result => {
      this.auctionOfTheDay = result.data;
    });

    this.searchForm.valueChanges.subscribe(console.log);
  }

  search(): void {
    this.ds.getAuctionsAll().subscribe(result => {
      console.log(result.data);
      this.allAuctions = result.data;
    });
    // this.foundCount = this.allAuctions.length;
  }
} 