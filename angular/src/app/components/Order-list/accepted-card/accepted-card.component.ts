import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-accepted-card',
  imports: [],
  templateUrl: './accepted-card.component.html',
  styleUrl: './accepted-card.component.css'
})
export class AcceptedCardComponent {
  @Input() order: any;
}
