export function FocusOnElementWithTabIndex(idx) {
    document.querySelector(`[tabindex="${idx}"]`).focus();
}