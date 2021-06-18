import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-challenge',
  templateUrl: './challenge.component.html',
  styleUrls: ['./challenge.component.css']
})
export class ChallengeComponent implements OnInit {
  images = [
    `https://cdn-images.farfetch-contents.com/15/31/40/36/15314036_27916085_1000.jpg`,
    `https://cdn-images.farfetch-contents.com/15/31/40/36/15314036_27916086_1000.jpg`,
    `https://cdn-images.farfetch-contents.com/15/31/40/36/15314036_27919049_1000.jpg`,
  ]
  
  constructor() { }

  ngOnInit(): void {
  }

}
