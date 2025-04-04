import { Component, Input, Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-invited-card',
  imports: [],
  templateUrl: './invited-card.component.html',
  styleUrl: './invited-card.component.css'
})
export class InvitedCardComponent {
  @Input() order: any;
  @Output() accept = new EventEmitter<void>();
  @Output() decline = new EventEmitter<void>();

  acceptOrder() {
    this.accept.emit();
  }

  declineOrder() {
    this.decline.emit();
  }
}
