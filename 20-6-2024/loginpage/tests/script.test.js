const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');

test('login test', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../login.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously' });
    const scriptEl = dom.window.document.createElement('script');
    scriptEl.textContent = script;
    dom.window.document.body.appendChild(scriptEl);

    dom.window.document.getElementById('username').value = 'dvsujan';
    dom.window.document.getElementById('password').value = 'pass123';
    dom.window.document.getElementById('login-form').dispatchEvent(new dom.window.Event('submit'));

    expect(dom.window.document.getElementById('message').innerText).toBe('Login successful');
    expect(dom.window.document.getElementById('message').style.color).toBe('green');
}
) ; 

test('login failed test', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../login.js'), 'utf8');
    const dom = new JSDOM(html, { runScripts: 'dangerously' });
    const scriptEl = dom.window.document.createElement('script');
    scriptEl.textContent = script;
    dom.window.document.body.appendChild(scriptEl);

    dom.window.document.getElementById('username').value = 'dvsujan';
    dom.window.document.getElementById('password').value = 'pass1234';
    dom.window.document.getElementById('login-form').dispatchEvent(new dom.window.Event('submit'));

    expect(dom.window.document.getElementById('message').innerText).toBe('Login Failed');
    expect(dom.window.document.getElementById('message').style.color).toBe('red');
}
) ;

