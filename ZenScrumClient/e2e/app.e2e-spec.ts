import { ZenScrumClientPage } from './app.po';

describe('zen-scrum-client App', function() {
  let page: ZenScrumClientPage;

  beforeEach(() => {
    page = new ZenScrumClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
