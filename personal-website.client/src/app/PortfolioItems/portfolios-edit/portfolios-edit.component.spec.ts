import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PortfoliosEditComponent } from './portfolios-edit.component';

describe('PortfoliosEditComponent', () => {
  let component: PortfoliosEditComponent;
  let fixture: ComponentFixture<PortfoliosEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PortfoliosEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PortfoliosEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
