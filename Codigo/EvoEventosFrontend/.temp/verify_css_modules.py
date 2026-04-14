import re
from pathlib import Path
root = Path('src/pages/home/components')
js_files = list(root.glob('*.jsx'))
css_files = list(root.glob('*.module.css'))
css_classes = {}
for css in css_files:
    text = css.read_text(encoding='utf-8')
    names = re.findall(r'\.(?P<name>[A-Za-z0-9_]+)', text)
    css_classes[css.name] = set(names)
errors = []
for js in js_files:
    text = js.read_text(encoding='utf-8')
    module_match = re.search(r"import\s+styles\s+from\s+['\"]\./(?P<css>[^'\"]+)['\"]", text)
    if not module_match:
        continue
    css_name = module_match.group('css')
    if css_name not in css_classes:
        errors.append((js.name, f'module {css_name} not found'))
        continue
    defs = css_classes[css_name]
    refs = re.findall(r'styles\.(?P<name>[A-Za-z0-9_]+)', text)
    for name in sorted(set(refs)):
        if name not in defs:
            errors.append((js.name, css_name, name))
if errors:
    print('MISMATCHES FOUND:')
    for err in errors:
        print(err)
    raise SystemExit(1)
print('No mismatches found between JSX styles and CSS module class names.')
