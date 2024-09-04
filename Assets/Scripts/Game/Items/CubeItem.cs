using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class CubeItem : Item
    {
        [Inject] private ImageLibService _imageLibService;
        [Inject] private ParticleService _particleService;
        [Inject] private ColorListSO _colorListSO;
        private MatchType _matchType;
        
        public void PrepareCubeItem(ItemBase itemBase, MatchType matchType, ItemType itemType)
        {
            ItemType = itemType;
            _matchType = matchType;
            Prepare(itemBase, GetSpriteForMatchType());
        }

        private Sprite GetSpriteForMatchType()
        {
            Assert.IsNotNull(_imageLibService);
            
            switch (_matchType)
            {
                case MatchType.None:
                    break;
                case MatchType.Green:
                    return _imageLibService.Images.greenCube;
                case MatchType.Yellow:
                    return _imageLibService.Images.yellowCube;
                case MatchType.Blue:
                    return _imageLibService.Images.blueCube;
                case MatchType.Red:
                    return _imageLibService.Images.redCube;
                case MatchType.Pink:
                    return _imageLibService.Images.pinkCube;
                case MatchType.Purple:
                    return _imageLibService.Images.purpleCube;
                case MatchType.SpecialType:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }

        public override void SetHint(int groupCount)
        {
            if (!MatchHelpers.IsMinSpecialMatch(groupCount))
            {
                SetDefaultItemSprite();
            }
            else if (MatchHelpers.IsRocketMatch(groupCount))
            {
                switch (_matchType)
                {
                    case MatchType.None:
                        break;
                    case MatchType.Green:
                        ChangeSprite(_imageLibService.Images.greenCubeRocket);
                        break;
                    case MatchType.Yellow:
                        ChangeSprite(_imageLibService.Images.yellowCubeRocket);
                        break;
                    case MatchType.Blue:
                        ChangeSprite(_imageLibService.Images.blueCubeRocket);
                        break;
                    case MatchType.Red:
                        ChangeSprite(_imageLibService.Images.redCubeRocket);
                        break;
                    case MatchType.Pink:
                        ChangeSprite(_imageLibService.Images.pinkCubeRocket);
                        break;
                    case MatchType.Purple:
                        ChangeSprite(_imageLibService.Images.purpleCubeRocket);
                        break;
                    case MatchType.SpecialType:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (MatchHelpers.IsBombMatch(groupCount))
            {
                switch (_matchType)
                {
                    case MatchType.None:
                        break;
                    case MatchType.Green:
                        ChangeSprite(_imageLibService.Images.greenCubeBomb);
                        break;
                    case MatchType.Yellow:
                        ChangeSprite(_imageLibService.Images.yellowCubeBomb);
                        break;
                    case MatchType.Blue:
                        ChangeSprite(_imageLibService.Images.blueCubeBomb);
                        break;
                    case MatchType.Red:
                        ChangeSprite(_imageLibService.Images.redCubeBomb);
                        break;
                    case MatchType.Pink:
                        ChangeSprite(_imageLibService.Images.pinkCubeBomb);
                        break;
                    case MatchType.Purple:
                        ChangeSprite(_imageLibService.Images.purpleCubeBomb);
                        break;
                    case MatchType.SpecialType:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (MatchHelpers.IsDiscoMatch(groupCount))
            {
                switch (_matchType)
                {
                    case MatchType.None:
                        break;
                    case MatchType.Green:
                        ChangeSprite(_imageLibService.Images.greenCubeDisco);
                        break;
                    case MatchType.Yellow:
                        ChangeSprite(_imageLibService.Images.yellowCubeDisco);
                        break;
                    case MatchType.Blue:
                        ChangeSprite(_imageLibService.Images.blueCubeDisco);
                        break;
                    case MatchType.Red:
                        ChangeSprite(_imageLibService.Images.redCubeDisco);
                        break;
                    case MatchType.Pink:
                        ChangeSprite(_imageLibService.Images.pinkCubeDisco);
                        break;
                    case MatchType.Purple:
                        ChangeSprite(_imageLibService.Images.purpleCubeDisco);
                        break;
                    case MatchType.SpecialType:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override MatchType GetMatchType()
        {
            return _matchType;
        }

        public override ItemType GetItemType()
        {
            return ItemType;
        }

        public override void TryExecute()
        {
            var fx = _particleService.Spawn("CubeParticle", transform.position, false);
            ChangeColor();
            
            base.TryExecute();

            return;
            void ChangeColor()
            {
                var main = fx.Particle.main;

                switch (_matchType)
                {
                    case MatchType.Green:
                        main.startColor = _colorListSO.green;
                        break;
                    case MatchType.Yellow:
                        main.startColor = _colorListSO.yellow;
                        break;
                    case MatchType.Blue:
                        main.startColor = _colorListSO.blue;
                        break;
                    case MatchType.Red:
                        main.startColor = _colorListSO.red;
                        break;
                    case MatchType.Pink:
                        main.startColor = _colorListSO.pink;
                        break;
                    case MatchType.Purple:
                        main.startColor = _colorListSO.purple;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                } 
                
                fx.Particle.Play();
            }
        }

        protected override Sprite GetDefaultItemSprite()
        {
            return GetSpriteForMatchType();
        }
    }