import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PortfoliosDetailComponent } from './portfolios-detail.component';

describe('PortfoliosDetailComponent', () => {
  let component: PortfoliosDetailComponent;
  let fixture: ComponentFixture<PortfoliosDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PortfoliosDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PortfoliosDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
