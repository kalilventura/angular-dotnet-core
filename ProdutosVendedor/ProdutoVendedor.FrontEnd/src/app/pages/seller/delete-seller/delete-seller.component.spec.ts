import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteSellerComponent } from './delete-seller.component';

describe('DeleteSellerComponent', () => {
  let component: DeleteSellerComponent;
  let fixture: ComponentFixture<DeleteSellerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteSellerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
