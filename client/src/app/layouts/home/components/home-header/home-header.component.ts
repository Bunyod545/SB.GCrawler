import { Component, EventEmitter, OnInit, Output } from '@angular/core';

/**
 * 
 */
@Component({
  selector: 'app-home-header',
  templateUrl: './home-header.component.html',
  styleUrls: ['./home-header.component.css']
})
export class HomeHeaderComponent implements OnInit {

  /**
   * 
   */
  @Output()
  menuClicked = new EventEmitter();

  /**
   * 
   */
  constructor() { }

  /**
   * 
   */
  ngOnInit(): void {
  }

  /**
   * 
   */
  menuClick() {
    this.menuClicked.emit();
  }
}
